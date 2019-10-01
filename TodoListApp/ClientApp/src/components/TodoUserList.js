import React, { Component } from 'react'
import axios from 'axios'

import IconButton from './template/IconButton'

const URL = 'http://todo-list-jean.azurewebsites.net/api'

export class TodoUserList extends Component {
    constructor(props) {
        super(props)
        this.state = {
            username: localStorage.getItem('user'),
            list: []
        };

        this.refreshList()
    }

    handleRemove(todo) {
        axios.delete(`${URL}/todo/${todo.id}`)
            .then(resp => this.refreshList())
    }

    refreshList() {
        const username = this.state.username
        axios.get(`${URL}/todo/filter?&username=${username}`)
            .then(resp => this.setState({ ...this.state, list: resp.data }))
    }

    handleEdit(todo) {
        const path = `/todo?guid=${todo.id}`
        window.location.href = path
    }

    renderRows() {


        const list = this.state.list || []
        return list.map(todo => (
            <tr key={todo.id}>
                <td>{todo.name}</td>
                <td>
                    <IconButton style='info' icon='edit'
                        onClick={() => this.handleEdit(todo)}></IconButton>
                    <IconButton style='danger' icon='trash-o'
                        onClick={() => this.handleRemove(todo)}></IconButton>
                </td>
            </tr>
        ))
    }

    render() {
        return (
            <>
                <h2>Your TodoLists</h2>
                <table className='table' >
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th className='tableActions'>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderRows()}
                    </tbody>
                 </table>
            </>
        )
    }
}