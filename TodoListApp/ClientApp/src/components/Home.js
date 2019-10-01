import React, { Component } from 'react';
import NewTodo from './NewTodo'
import AboutText from './template/AboutText'

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <AboutText/>
            <NewTodo/>
      </div>
    );
  }
}
