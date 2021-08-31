import React, { Component } from 'react'

export default function ItemSelectorElement(props) {
  return (
    <label class='form-check'>
      <input
        type={props.type}
        class='form-check-input'
        value={props.id}
        name='exampleRadio'
      />
      <span class='form-check-label'>{props.body}</span>
    </label>
  )
}
