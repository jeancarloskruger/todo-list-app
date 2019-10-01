import React, { Component } from 'react';
import { Route } from 'react-router-dom';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { About } from './components/About';
import { Todo } from './components/Todo';
import { AuthorizeRoute } from './components/AuthorizeRoute'
import { Login } from './components/Login'
import { TodoUserList } from './components/TodoUserList'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/login' component={Login} />
            <AuthorizeRoute exact path='/' component={Home} />
            <AuthorizeRoute path='/userlist' component={TodoUserList} />
            <AuthorizeRoute path='/Todo' component={Todo} />
            <AuthorizeRoute path='/about' component={About} />
      </Layout>
    );
  }
}
