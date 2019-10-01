import React, { Component } from 'react'
import axios from 'axios'

import PageHeader from './template/TitlePage'
import TodoNewForm from './TodoNewForm'

const URL = 'http://todo-list-jean.azurewebsites.net/api/todo'

export default class NewTodo extends Component {
    constructor(props) {
        super(props)
        this.state = {
            nameList: '',
            username: localStorage.getItem('user'),
        }

        this.handleChange = this.handleChange.bind(this)
        this.handleAdd = this.handleAdd.bind(this)
        this.handleClear = this.handleClear.bind(this)
    }

    handleChange(e) {
        this.setState({ ...this.state, nameList: e.target.value })
    }

    handleAdd() {
        const name = this.state.nameList
        const username = this.state.username
        if (name) {

            axios.post(`${URL}/create`, { name, username })
                .then(resp => this.redirectoToEdit(resp.data.id))
        }
    }

    redirectoToEdit(guid) {
        const path = `/todo?guid=${guid}`
        window.location.href = path
    }

    handleClear() {
        this.setState({ ...this.state, nameList: '' })
    }

    render() {
        return (
            <div>
                <PageHeader name='Create' small={this.state.nameList}></PageHeader>
                <TodoNewForm
                    nameList={this.state.nameList}
                    handleChange={this.handleChange}
                    handleAdd={this.handleAdd}
                    handleClear={this.handleClear} />
            </div>
        )
    }
}