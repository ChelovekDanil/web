import logo from '../source/logo.png'
import accountIcon from '../source/accountIcon.png'
import './style/Header.css'
import { Link } from 'react-router-dom'

function Header() {
    return (
      <div className="Header">
        <img src={logo} alt="logo" height={50} width={180} id="logo" />
        <div className='ButtonBlock'>
            <Link to='/popularmovies' className='link' id='popular'>Popular</Link>
            <Link to='/films' className='link' id='film'>Films</Link>
            <Link to='/serials' className='link' id='serial'>Serials</Link>
        </div>
        <img src={accountIcon} alt="account icon" height={60} width={60} id="accountIcon"/>
      </div>
    );
  }
  
export default Header;
