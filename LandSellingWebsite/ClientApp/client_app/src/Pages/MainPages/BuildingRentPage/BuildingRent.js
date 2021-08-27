import React from 'react'
import { Container, Row, Col } from 'react-bootstrap'

function BuildingRent() {
  return (
    <>
      <Container borderStyle='solid'>
        <h2 className='text-center m-4'>ALL OFFERS</h2>
        <label
          style={{ textAlign: 'center', display: 'block' }}
          className='text m-4'
        >
          Be prepared to travel anywhere, because our cars already are
        </label>
        <select
          defaultValue='Name'
          aria-label='Default select example'
          onChange={this.handleSort}
          style={{ float: 'right' }}
        >
          <option value='Name' selected>
            Name
          </option>
          <option value='High-to-low'>From high to low</option>
          <option value='Low-to-high'>From low to high</option>
        </select>
        <h6>Filters:</h6>
        <Row>
          <Col lg={3}>
            {/* City selector item*/}
            <OneItemSelector
              onChangeValue={this.handleCitySelect}
              Title='City:'
              postArray={this.state.cityArray}
            />

            {/* Period selector item*/}
            <RangeSelectorElement
              Title='Period of rent:'
              LeftBorder='From'
              LeftPlaceholder='01/09/2021'
              RightBorder='To'
              RightPlaceholder='02/09/2021'
              Type='date'
            />

            {/* Price selector item*/}
            <RangeSelectorElement
              onChangeValue={this.handlePriceSelect}
              Title='Price:'
              LeftBorder='From'
              LeftPlaceholder='$0'
              RightBorder='To'
              RightPlaceholder='$1000'
              Type='number'
            />

            {/* Brands selector item*/}
            <MultiItemSelector
              onChangeValue={this.handleBrandSelect}
              Title='Brands:'
              postArray={this.state.carBrandArray}
            />

            {/* Transmition selector item*/}
            <MultiItemSelector
              onChangeValue={this.handleTransmitionSelect}
              Title='Transmition:'
              postArray={this.state.transmitionArray}
            />

            {/* Fuel selector item*/}
            <MultiItemSelector
              onChangeValue={this.handleFuelTypeSelect}
              Title='Fuel type:'
              postArray={this.state.fuelArray}
            />

            {/* Number of seats selector item*/}
            <RangeSelectorElement
              onChangeValue={this.handleSeatsSelect}
              Title='Number of seats:'
              LeftBorder='From'
              LeftPlaceholder='1'
              RightBorder='To'
              RightPlaceholder='20'
              Type='number'
            />

            {/* Car cards*/}
          </Col>
          <Col lg={9}>
            <CarCardsDeck id='cars-list' postArray={sortedBooks} />
          </Col>
        </Row>
      </Container>
    </>
  )
}

export default BuildingRent
