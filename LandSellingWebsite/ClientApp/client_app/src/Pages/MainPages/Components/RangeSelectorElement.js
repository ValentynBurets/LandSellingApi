import React from 'react'

export default function RangeSelectorElement(props) {
  return (
    <article class='card-group-item'>
      <header class='card-header'>
        <h6 class='title'>{props.Title}"</h6>
      </header>
      <div class='filter-content'>
        <div class='form-row' onChange={props.onChangeValue}>
          <div class='form-row' onChange={props.onChangeValue}>
            <div class='form-group col-md-6'>
              <label>{props.LeftBorder}</label>
              <input
                id='from'
                type={props.Type}
                class='form-control'
                placeholder={props.LeftPlaceholder}
              />
            </div>
            <div class='form-group col-md-6 text-right'>
              <label>{props.RightBorder}</label>
              <input
                id='to'
                type={props.Type}
                class='form-control'
                placeholder={props.RightPlaceholder}
              />
            </div>
          </div>
        </div>
      </div>
    </article>
  )
}
