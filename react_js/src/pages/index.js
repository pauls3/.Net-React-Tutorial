import React,{Component} from 'react';
// import { useNavigate } from "react-router-dom";

// const Home = () => {
// return (
// 	<div
// 	style={{
// 		display: 'flex',
// 		justifyContent: 'Left',
// 		alignItems: 'Left',
// 		height: '50%',
// 		margin: '0 200px',
// 		color: 'black'
// 	}}
// 	>
// 	<h2>
// 		Home page
// 	</h2>
// 	</div>
// );
// };

export class Home extends Component{
    render(){
        return (
            <div className="mt-5 d-flex justify-content-left">
                This is Home page.
            </div>
          )
    }
}


export default Home;
