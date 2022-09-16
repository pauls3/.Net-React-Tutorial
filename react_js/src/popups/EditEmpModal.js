import React,{Component} from 'react';
import {Modal, Button, Row, Col, Form, Image} from 'react-bootstrap';


export class EditEmpModal extends Component{
    constructor(props){
        super(props);
        this.state={deps:[]};
        this.handleSubmit=this.handleSubmit.bind(this);
        this.handleFileSelected=this.handleFileSelected.bind(this);
    }
    photofilename = "anonymous.png";
    imagesrc = process.env.REACT_APP_PHOTOPATH+this.photofilename;

    componentDidMount(){
        fetch(process.env.REACT_APP_API+'department')
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        });
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'employee',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                EmployeeId:event.target.EmployeeId.value,
                EmployeeName:event.target.EmployeeName.value,
                Department:event.target.Department.value,
                DateOfJoining:event.target.DateOfJoining.value,
                PhotoFileName:this.photofilename
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            // Alert user if successful
            alert(result);
        },
        (error)=>{
            // Alert user if failed
            alert('Failed')
        })
    }

    // Method to save uploaded photo
    handleFileSelected(event){
        event.preventDefault();
        this.photofilename=event.target.files[0].name;
        const formData = new FormData();
        formData.append(
            "myFile",
            event.target.files[0],
            event.target.files[0].name
        );

        // send image to api
        fetch(process.env.REACT_APP_API+'Employee/SaveFile',{
            method:'POST',
            body:formData,
            })
            .then(res=>res.json())
            .then((result)=>{
                this.imagesrc=process.env.REACT_APP_PHOTOPATH+result;
            },
            (error)=>{
                alert('Failed');
            })
        
    }


    render(){
        return (
            <div className="container">
                <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered>
                    <Modal.Header clooseButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edit Employee
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="EmployeeId">
                                        <Form.Label>EmployeeId</Form.Label>
                                        <Form.Control type="text" name="EmployeeId" 
                                        required 
                                        placeholder="EmployeeId"
                                        disabled
                                        defaultValue={this.props.empid}/>
                                    </Form.Group>

                                    <Form.Group controlId="EmployeeName">
                                        <Form.Label>EmployeeName</Form.Label>
                                        <Form.Control type="text" name="EmployeeName" required placeholder="EmployeeName"
                                        defaultValue={this.props.empname}/>
                                    </Form.Group>

                                    <Form.Group controlId="Department">
                                        <Form.Label>Department</Form.Label>
                                        <Form.Control as="select"> defaultValue={this.props.depmt}
                                            {this.state.deps.map(dep=>
                                                <option key={dep.DepartmentId}>{dep.DepartmentName}</option>)}
                                        </Form.Control>
                                    </Form.Group>

                                    <Form.Group controlId="DateOfJoining">
                                        <Form.Label>DateOfJ</Form.Label>
                                        <Form.Control
                                        type="date"
                                        name="DateOfJoining"
                                        required
                                        placeholder="DateOfJoining"
                                        defaultValue={this.props.doj}
                                        />
                                            
                                    </Form.Group>

                                    <Form.Group>
                                        <Button variante="primary" type="submit">
                                            Edit Employee
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>

                            <Col sm={6}>
                                <Image width="200px" height="200px" src={process.env.REACT_APP_PHOTOPATH+this.props.photofilename}/>
                                <input onChange={this.handleFileSelected} type="File"/>
                            </Col>
                        </Row>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>
                            Close
                        </Button>
                    </Modal.Footer>

                </Modal>
            </div>
        )
    }
}

export default EditEmpModal;