import React from 'react';
import {
Nav,
NavLink,
Bars,
NavMenu,
} from './NavbarElements';

const Navbar = () => {
return (
	<div
	// style={{
	// 	// display: 'flex',
	// 	// justifyContent: 'Center',
	// 	// alignItems: 'Center',
	// 	// height: '100vh',
	// 	// margin: '20px 10px'
	// }}
	>
	<Nav>
		<Bars />

		<NavMenu>
		<NavLink to='/' activeStyle>
			Home
		</NavLink>
		<NavLink to='/department' activeStyle>
			Department
		</NavLink>
		<NavLink to='/employee' activeStyle>
			Employee
		</NavLink>
		{/* Second Nav */}
		{/* <NavBtnLink to='/sign-in'>Sign In</NavBtnLink> */}
		</NavMenu>
	</Nav>
	</div>
);
};

export default Navbar;
