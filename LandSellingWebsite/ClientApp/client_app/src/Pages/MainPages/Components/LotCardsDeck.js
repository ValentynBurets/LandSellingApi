import React from 'react'
import { CardDeck } from 'react-bootstrap'

import LotCard from './LotCard'

export default function LotCardsDeck(props) {
  return (
    <CardDeck>
      {props.postArray.map((post, index) => {
        return (
          <LotCard
            Id={post.id}
            Title={post.Address}
            Description={post.Description}
            Price={post.price}
            Images={post.Images}
            Square={post.Square}
          />
        )
      })}
    </CardDeck>
  )
}
