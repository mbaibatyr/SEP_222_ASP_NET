import React, { Component } from 'react';
import NavMenu from './NavMenu';

export class Layout extends Component {
    render() {
        return (
            <div style={{
                marginLeft: 20,
                marginRight: 20
            }} >
                <NavMenu />
                <div>
                    {this.props.children}
                </div>
            </div>
        );
    }
}
