// import React from 'react';

// const Employee = () => {
// return (
// 	<div
// 	style={{
// 		display: 'flex',
// 		justifyContent: 'Right',
// 		alignItems: 'Right',
// 		height: '100vh'
// 	}}
// 	>
// 	<h1>Employee Page</h1>
// 	</div>
// );
// };

// export default Employee;
import React,{Component} from 'react';

export class Employee extends Component{
    render(){
        return (
            <div className="mt-5 d-flex justify-content-left">
                This is Employee page.
            </div>
          )
    }
}

export default Employee;