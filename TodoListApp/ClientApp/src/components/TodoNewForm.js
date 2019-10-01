import React from 'react'
import IconButton from './template/IconButton'

export default props => {
    const keyHandler = (e) => {
        if (e.key === 'Enter') {
            e.shiftKey ? props.handleSearch() : props.handleAdd()
        } else if (e.key === 'Escape') {
            props.handleClear()
        }
    }

    return (
        <div role='form' className='todoForm'>
            <div className="form-group row">
                <div className="col-sm-8">
                    <input id='nameList' className='form-control'
                        placeholder='Enter a new list name'
                        onChange={props.handleChange}
                        onKeyUp={keyHandler}
                        value={props.nameList}></input>
                </div>

                <IconButton style='primary' icon='plus'
                    onClick={props.handleAdd}></IconButton>
                <IconButton style='default' icon='close'
                    onClick={props.handleClear}></IconButton>
            </div>
        </div>
    )
}