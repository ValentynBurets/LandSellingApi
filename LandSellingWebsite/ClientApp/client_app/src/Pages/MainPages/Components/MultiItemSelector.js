import React from 'react'

export default function MultiItemSelector(props) {
  return (
    <article class='card-group-item'>
      <header class='card-header'>
        <h6 class='title'>{props.Title}</h6>
      </header>
      <div class='filter-content'>
        <div class='card-body' onChange={props.onChangeValue}>
          <form>
            {props.postArray.map((post, index) => {
              return (
                <label class='form-check'>
                  <input
                    type='checkbox'
                    class='form-check-input'
                    value={post.id}
                    name='exampleCheck'
                  />
                  <span class='form-check-label'>{post.name}</span>
                </label>
              )
            })}
          </form>
        </div>
      </div>
    </article>
  )
}
