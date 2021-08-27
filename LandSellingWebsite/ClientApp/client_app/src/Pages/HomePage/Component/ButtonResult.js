import React from 'react'
import { Container } from 'react-bootstrap'

import Button from 'react-bootstrap/Button'
import { useHistory } from 'react-router-dom'

export const ButtonResult = (props) => {
  let history = useHistory()

  var personInfo = localStorage.getItem('currentUser')
  var UserData = JSON.parse(personInfo)
  //console.log(UserData)

  const newPage = (path) => {
    history.push({
      pathname: '/user/' + path, // userId must be here
      //pathname: '/user/' + UserData?.id + '/' + path, // userId must be here
      state: { personId: UserData?.id }, // here too
    })
  }

  return (
    <Container>
      <Button
        className='RentButton'
        variant='warning'
        onClick={() => {
          newPage(props.param + '/rent')
        }}
      >
        Rent
      </Button>

      <Button
        className='BookingButton'
        variant='warning'
        onClick={() => {
          newPage(props.param + '/selling')
        }}
      >
        Buy
      </Button>
    </Container>
  )
}
