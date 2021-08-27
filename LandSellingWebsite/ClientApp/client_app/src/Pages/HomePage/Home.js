import React from 'react'
import { Container, Col, Row } from 'react-bootstrap'
import './Home.css'
import { SpecialButton } from './Component/SpecialButton'

function HomePage() {
  return (
    <Container className='PageStyle'>
      <Row>
        <Col>
          <h1>LAND AND BUILDING</h1>
          <h5>Find you best offer for you with our service</h5>
        </Col>
        <Col>
          <SpecialButton param='building' />
          <SpecialButton param='land' />
        </Col>
      </Row>
      <Row>
        <h1> Our benefites... ... ... ... ...</h1>
      </Row>
    </Container>
  )
}

export default HomePage
