import React, { Component } from 'react';
import AboutText from './template/AboutText';

export class About extends Component {
  render () {
      return (
          <>
              <AboutText />
              <a href="/">Create a new list now!!!</a>
          </>
    );
  }
}
