import React, { Component } from 'react';

export class Login extends Component {
    constructor(props) {
        super(props);

        localStorage.removeItem('user');

        this.state = {
            username: '',
            password: '',
            submitted: false,
            loading: false,
            error: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState({ submitted: true });
        const { username } = this.state;

        // stop here if form is invalid
        if (!(username)) {
            return;
        }

        this.setState({ loading: true });
        this.login(username)
        this.redirectoToHome()
    }

    redirectoToHome() {
        window.location.href = `/`
    }

    login(username) {
        localStorage.setItem('user', username);
    }

    render() {
        const { username, submitted } = this.state;
        return (
            <div className="col-md-6 col-md-offset-3">
                <h2>Login</h2>
                <form name="form" onSubmit={this.handleSubmit}>
                    <div className={'form-group' + (submitted && !username ? ' has-error' : '')}>
                        <label htmlFor="username">Email</label>
                        <input type="text" className="form-control" name="username" value={username} onChange={this.handleChange} />
                        {submitted && !username &&
                            <div className="help-block">email is required</div>
                        }
                    </div>
                    <div className="form-group">
                        <button className="btn btn-primary">Login</button>
                    </div>
                </form>
            </div>
        );
    }
}