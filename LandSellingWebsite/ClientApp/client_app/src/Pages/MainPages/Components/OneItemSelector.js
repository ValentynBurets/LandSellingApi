import React from 'react'

export default function OneItemSelector(props) {
  return (
    <div onChange={props.onChangeValue}>
      {props.postArray.map((post, index) => {
        return (
          <label class='form-check'>
            <input
              type='radio'
              class='form-check-input'
              value={post.id}
              name='exampleRadio'
            >
              {post.name}
            </input>
          </label>
        )
      })}
    </div>
  )
}
