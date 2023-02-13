import React, { useState } from 'react';
import { navLinks } from '../constants';

const Navbar = () => {
  const [active, setActive] = useState("sports");


  return (
    <nav className='w-full flex py-6 justify-between items-center navbar'>
      <ul className='list-none flex justify-end items-center flex-1'>
      {navLinks.map((nav, index) =>(
        <li
            key={nav.id}
            className={`font-poppins font-normal cursor-pointer xs:text-[13px] text-[16px] 
            ${active === nav.title ? "text-white" : "text-dimWhite"} 
            ${index === navLinks.length - 1 ? "mr-0" : "xs:mr-6 mr-10"}
            ${active === nav.title ? "underline decoration-[#50d71e]" : ""}`}
            onClick={() => setActive(nav.title)}
          >
            <a href={`#${nav.id}`}>{nav.title}</a>
           </li>
      ))}
      </ul>
    </nav>
  )
}

export default Navbar