import React, { useState, useEffect } from 'react';
import { Container, Navbar, NavLink } from 'reactstrap';
import { Link, useHistory } from 'react-router-dom';
import './NavMenu.css';

const NavMenu = () => {


    return (
        <div>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <>
                        <NavLink tag={Link} to="/">Main</NavLink>
                    </>
                </Container>
            </Navbar>
        </div>
    )

}
export default NavMenu