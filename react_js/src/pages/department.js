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
import {Table} from 'react-bootstrap';

import {Button, ButtonToolbar} from 'react-bootstrap';
import {AddDepModal} from '../popups/AddDepModal';
import {EditDepModal} from '../popups/EditDepModal';

export class Department extends Component{

    constructor(props){
        super(props);
        this.state={deps:[], addModalShow:false, editModalShow:false}
    }

    // refreshes deparment's array data
    refreshList(){
        fetch(process.env.REACT_APP_API+'department')
        .then(response=>response.json())
        .then(data => {
            this.setState({deps:data});
        })
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    deleteDep(depid){
        if(window.confirm('Are you sure? ' + depid)){
            fetch(process.env.REACT_APP_API+'department/'+depid,{
                method:'DELETE',
                header:{'Accept':'application/json',
            'Content-Type':'application/json'}
            })
        }
    }

    render(){
        const {deps, depid, depname} = this.state;
        let addModalClose=()=>this.setState({addModalShow:false});
        let editModalClose=()=>this.setState({editModalShow:false});


        return (
            <div>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>DepartmentId</th>
                            <th>DepartmentName</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {deps.map(dep => 
                            <tr key={dep.DepartmentId}>
                                <td>{dep.DepartmentId}</td>
                                <td>{dep.DepartmentName}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                        onClick={()=>this.setState({editModalShow:true, depid:dep.DepartmentId, depname:dep.DepartmentName})}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                        onClick={()=>this.deleteDep(dep.DepartmentId)}>
                                            Delete
                                        </Button>


                                    </ButtonToolbar>
                                </td>
                            </tr>
                            )}
                    </tbody>
                </Table>
                
                <ButtonToolbar>
                    <Button variant='primary'
                    onClick={()=>this.setState({addModalShow:true})}>
                        Add Department
                    </Button>
                    
                    <AddDepModal show={this.state.addModalShow}
                    onHide={addModalClose}/>
                    
                    <EditDepModal show={this.state.editModalShow}
                    onHide={editModalClose}
                    depid={depid}
                    depname={depname}/>

                    
                </ButtonToolbar>
            </div>
          )
    }
}

export default Department;