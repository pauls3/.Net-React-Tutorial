// import React from 'react';

// const Department = () => {
// return (
// 	<div>
// 	<h1>Department Page</h1>
// 	</div>
// );
// };

// export default Department;

import React,{Component} from 'react';

export class Department extends Component{
    render(){
        return (
            <div className="mt-5 d-flex justify-content-left">
                This is Department page.
            </div>
          )
    }
}

export default Department;