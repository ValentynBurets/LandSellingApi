import React from 'react'
import { ButtonResult } from './ButtonResult'

export const SpecialButton = (props) => {
  const [showResults, setShowResults] = React.useState(false)
  const onClick = () => setShowResults(true)
  return (
    <div>
      <input type='submit' value={props.param} onClick={onClick} />
      {showResults ? <ButtonResult param={props.param} /> : null}
    </div>
  )
}
