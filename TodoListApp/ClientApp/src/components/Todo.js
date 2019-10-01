import React, { Component } from 'react'
import axios from 'axios'
import queryString from 'query-string'
import Modal, { closeStyle } from 'simple-react-modal'

import PageHeader from './template/TitlePage'
import TodoForm from './TodoForm'
import TodoItemList from './TodoItemList'
import TodoShareForm from './TodoShareForm'

const URL = 'http://todo-list-jean.azurewebsites.net/api'

export class Todo extends Component {
    constructor(props) {
        super(props)
        this.state = {
            nameList: '',
            description: '',
            list: [],
            guid: '',
            mail: '',
            showEdit: false,
            todoItemId: 0,
            todoItemDescription: '',
            username: localStorage.getItem('user'),
        }

        this.handleChange = this.handleChange.bind(this)
        this.handleAdd = this.handleAdd.bind(this)
        this.handleSearch = this.handleSearch.bind(this)
        this.handleClear = this.handleClear.bind(this)
        this.handleEdit = this.handleEdit.bind(this)

        this.handleMarkAsDone = this.handleMarkAsDone.bind(this)
        this.handleMarkAsPending = this.handleMarkAsPending.bind(this)
        this.handleRemove = this.handleRemove.bind(this)

        this.handleShareChange = this.handleShareChange.bind(this)
        this.handleShare = this.handleShare.bind(this)

        this.handleShowModal = this.handleShowModal.bind(this)
        this.handleCloseModal = this.handleCloseModal.bind(this)
        this.handleItemChange = this.handleItemChange.bind(this)

        this.startListEditing()
    }

    startListEditing() {
        const values = queryString.parse(this.props.location.search)
        const guid = values.guid ? values.guid : ''
        axios.get(`${URL}/todo?id=${guid}`)
            .then(resp => resp.data.items ? this.setState({ ...this.state, nameList: resp.data.name, list: resp.data.items, guid }) : this.redirectoToHome())
    }

    handleEdit(e) {
        e.preventDefault();

        const { todoItemId, todoItemDescription } = this.state;
        axios.put(`${URL}/todoitem/update/${todoItemId}/${todoItemDescription}`)
            .then(resp => this.refresh())

        this.setState({ ...this.state, showEdit: false})
    }

    redirectoToHome() {
        const path = `/`
        window.location.href = path
    }

    refresh(description = '') {
        axios.get(`${URL}/todoitem/filter?&description=${description}&todoId=${this.state.guid}`)
            .then(resp => this.setState({ ...this.state, description, list: resp.data }))
    }

    handleSearch() {
        this.refresh(this.state.description)
    }

    handleChange(e) {
        this.setState({ ...this.state, description: e.target.value })
    }

    handleAdd() {
        const description = this.state.description
        axios.post(`${URL}/todoitem`, { description, TodoId: this.state.guid })
            .then(resp => this.refresh())
    }

    handleShareChange(e) {
        this.setState({ ...this.state, mail: e.target.value })
    }

    handleItemChange(e) {
        this.setState({ ...this.state, todoItemDescription: e.target.value })
    }

    handleShare() {

        const { mail, guid, username } = this.state;

        axios.put(`${URL}/todo/share/${username}/${mail}/${guid}`)
            .then(resp => this.clearEmail())
    }

    clearEmail() {
        this.setState({ ...this.state, mail: '' })
    }

    handleRemove(todo) {
        axios.delete(`${URL}/todoitem/${todo.id}`)
            .then(resp => this.refresh(this.state.description))
    }

    handleMarkAsDone(todo) {
        axios.put(`${URL}/todoitem/${todo.id}`, { ...todo, done: true })
            .then(resp => this.refresh(this.state.description))
    }

    handleMarkAsPending(todo) {
        axios.put(`${URL}/todoitem/${todo.id}`, { ...todo, done: false })
            .then(resp => this.refresh(this.state.description))
    }

    handleClear() {
        this.refresh()
    }

    handleShowModal(todo) {
        this.setState({ ...this.state, todoItemId: todo.id, todoItemDescription: todo.description, showEdit: true })
    }

    handleCloseModal() {
        this.setState({ showEdit: false })
    }

    render() {
        const { todoItemDescription } = this.state;
        return (
            <div>

                <Modal show={this.state.showEdit} onClose={this.handleCloseModal} transitionSpeed={1000}>
                    <form name="form" onSubmit={this.handleEdit}>
                        <div className={'form-group'}>
                            <label htmlFor="todoItemDescription">Task: </label>
                            <input type="text" className="form-control" name="todoItemDescription" value={todoItemDescription} onChange={this.handleItemChange} />
                        </div>
                        <div className="form-group">
                            <button className="btn btn-primary">Save</button>
                        </div>
                    </form>
                </Modal>

                <TodoShareForm
                    mail={this.state.mail}
                    handleShare={this.handleShare}
                    handleShareChange={this.handleShareChange} />

                <PageHeader name='Edit List: ' small={this.state.nameList}></PageHeader>

                <TodoForm
                    description={this.state.description}
                    handleChange={this.handleChange}
                    handleAdd={this.handleAdd}
                    handleSearch={this.handleSearch}
                    handleClear={this.handleClear} />

                <TodoItemList
                    list={this.state.list}
                    showEdit={this.state.showEdit}
                    handleMarkAsDone={this.handleMarkAsDone}
                    handleMarkAsPending={this.handleMarkAsPending}
                    handleRemove={this.handleRemove}
                    handleShowModal={this.handleShowModal} />
            </div>
        )
    }
}