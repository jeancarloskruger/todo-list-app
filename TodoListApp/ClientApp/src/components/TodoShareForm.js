import React from 'react'
import IconButton from './template/IconButton'

export default props => {
    return (
        <div>
            <div className="form-group row float-right">
                <label className='col-sm-2 col-form-label'>Share</label>
                <div className="col-sm-8">
                    <input id='mail' className='form-control'
                        placeholder='share by email'
                        onChange={props.handleShareChange}
                        value={props.mail}></input>
                 </div>
                <IconButton style='outline-info' icon='share-alt' className='col-md-2'
                    onClick={props.handleShare}></IconButton>
            </div>
        </div>
    )
}