import React from 'react'
import {sportsHeading, freeBetsHeading, joinNow} from "../constants"
import styles from '../style'

import ModalLoginForm from './ModalLoginForm'

const CTA = () => {

  const [openDialog, setOpenDialog] = React.useState(false);

  return (
    <div className={`${styles.cta_footer} flex flex-col justify-center`}>
        <div className='flex justify-center'><span className='text-[12px]'>{sportsHeading}</span></div>
        <div className='flex justify-center'><span className=' font-bold text-[17px]'>{freeBetsHeading}</span></div>
        <div className='flex justify-center'>
        <button onClick={() => setOpenDialog(true)} className='btn btn-primary cta'>{joinNow}</button>
        </div>

        {openDialog && <ModalLoginForm isCtaClicked={openDialog}/>}
    </div>
  )
}

export default CTA