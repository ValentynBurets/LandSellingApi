import React from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import logoFacebook from '../Images/Logo/FacebookLogo.png'
import logoTelegram from '../Images/Logo/TelegramLogo.png'
import logoYoutube from '../Images/Logo/YoutubeLogo.png'
import logoInsta from '../Images/Logo/InstagramLogo.png'
import logo from '../Images/Logo/Logo.png'
const Footer = () => (
  <Container
    fluid
    style={{
      backgroundColor: '#212529',
      color: '#fff',
      //position: 'fixed',
      left: '0',
      //bottom: '0',
      width: '100%',
    }}
  >
    <Row>
      <Col
        lg={2}
        style={{
          width: '25%',
        }}
      >
        <center>
          <a href='/'>
            <img
              src={logo}
              height='60%'
              width='70%'
              className='d-inline-block align-top'
              alt='Logo'
            />
          </a>
          <label>LandSelling</label>
          <label>All rights reserved © 2021</label>
        </center>
      </Col>
      <Col
        lg={2}
        style={{
          width: '25%',
        }}
      >
        <div
          style={{
            margin: '20px 10px',
          }}
        >
          <label>Navigation:</label>
          <div style={{ margin: '0px 20px' }}>
            <a style={{ color: 'grey' }}>Lots</a>
            <br />
            <a style={{ color: 'grey' }}>About us</a>
            <br />
            <a style={{ color: 'grey' }}>Rules</a>
          </div>
        </div>
      </Col>
      <Col
        lg={4}
        style={{
          width: '25%',
        }}
      >
        <div style={{ margin: '15px 10px' }}>
          <label>Social media:</label>
          <div>
            <div style={{ margin: '10px 0px' }}>
              <a href='/'>
                <img
                  src={logoYoutube}
                  height='6%'
                  width='6%'
                  className='d-inline-block align-top'
                  alt='Logo'
                />
              </a>
              <a style={{ color: 'grey', margin: '0px 10px' }}>
                YouTube: LandSelling.ua
              </a>
              <br />
            </div>

            <div style={{ margin: '10px 0px' }}>
              <a href='/'>
                <img
                  src={logoInsta}
                  height='6%'
                  width='6%'
                  className='d-inline-block align-top'
                  alt='Logo'
                />
              </a>
              <a style={{ color: 'grey', margin: '0px 10px' }}>
                Instagram: @LandSelling.ua
              </a>
              <br />
            </div>

            <div style={{ margin: '10px 0px' }}>
              <a href='/'>
                <img
                  src={logoFacebook}
                  height='6%'
                  width='6%'
                  className='d-inline-block align-top'
                  alt='Logo'
                />
              </a>
              <a style={{ color: 'grey', margin: '0px 10px' }}>
                Facebook: LandSelling
              </a>
              <br style={{ margin: '10px' }} />
            </div>

            <div style={{ margin: '10px 0px' }}>
              <a href='/'>
                <img
                  src={logoTelegram}
                  height='6%'
                  width='6%'
                  className='d-inline-block align-top'
                  alt='Logo'
                />
              </a>
              <a style={{ color: 'grey', margin: '0px 10px' }}>
                Telegram: LandSelling
              </a>
              <br style={{ margin: '10px' }} />
            </div>
          </div>
        </div>
      </Col>

      <Col
        lg={4}
        style={{
          width: '25%',
        }}
      >
        <div style={{ float: 'left', margin: '12px 10px' }}>
          <label>Contact us: </label>
          <br />
          <a href='tel:0800600000' style={{ color: 'grey', fontSize: '20px' }}>
            +380 959 171 229
          </a>
        </div>
      </Col>
    </Row>
  </Container>
)
export default Footer
