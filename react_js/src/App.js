import React from 'react';
import './App.css';
import Navbar from './components/Navbar';
import { Navigation } from './components/Navigation/Navigation';
// import { HashRouter as Router, Routes, Route } from 'react-router-dom';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import Home from './pages';
import Department from './pages/department';
import Employee from './pages/employee';
import {Research} from './pages/research';

function App() {
return (
  // <div className="container">
  //   <h3 className='m-3 d-flex justify-content-center'>
  //     Test
  //   </h3>
  // </div>

  <BrowserRouter forceRefresh>
    <div className="container">
      <h3 className='m-3 d-flex justify-content-center'>
        Test
      </h3>

	<Navbar />
  {/* <Navigation/> */}
	<Switch>
		<Route path='/' component={Home} exact/>
		<Route path='/department' component={Department} />
		<Route path='/employee' component={Employee} />
    {/* <Route path='/research' component={Research} /> */}
	</Switch>
  </div>
	</BrowserRouter>
);
}

// function App() {
//   return (
//     <BrowserRouter>
//     <div className="container">
//      <h3 className="m-3 d-flex justify-content-center">
//        React JS Tutorial
//      </h3>


//      <Switch>
//        <Route path='/' component={Home} exact/>
//        <Route path='/department' component={Department}/>
//        <Route path='/employee' component={Employee}/>
//      </Switch>
//     </div>
//     </BrowserRouter>
//   );
// }

export default App;
