import React from 'react'
import { Container, Col, Row } from 'react-bootstrap'
//import { HomeBackground } from './green-fields.jpg'
import './Home.css'
import Button from 'react-bootstrap/Button'
import { useHistory } from 'react-router-dom'

function HomePage() {
  let history = useHistory()

  const newRent = () => {
    //setTutorial(initialTutorialState)
    //console.log(rent)
    history.push({
      pathname: '/user/' + UserData?.id, // userId must be here
      state: { personId: UserData?.id }, // here too
    })
  }

  const BuildingButton = () => {
    const [showResults, setShowResults] = React.useState(false)
    const onClick = () => setShowResults(true)
    return (
      <div>
        <input type='submit' value='Building' onClick={onClick} />
        {showResults ? <BuildingResults /> : null}
      </div>
    )
  }

  const BuildingResults = () => (
    <Button className='BookingButton' variant='warning' onClick={newRent}>
      Rent
    </Button>
  )

  return (
    <Container className='PageStyle'>
      <Row>
        <Col>
          <h1>LAND AND BUILDING</h1>
          <h5>Find you best offer for for you with our service</h5>
        </Col>
        <Col>
          <Search />
        </Col>
      </Row>
      <Row>
        <Col></Col>
        <Col></Col>
      </Row>
    </Container>
  )
}

export default HomePage
