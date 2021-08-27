import './App.css'
import React from 'react'
import { BrowserRouter as Router, Route } from 'react-router-dom'

import { Layout } from './Components/Layout'
import Home from './Pages/HomePage/Home'
import 'bootstrap/dist/css/bootstrap.min.css'
import { BuildingRent } from './Pages/BuildingRentPage/BuildingRent'

function App() {
  return (
    <Router>
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/building/rent' component={BuildingRent} />
      </Layout>
    </Router>
  )
}

export default App
