import logo from '../source/logo.png';
import HeaderAuth from './HeaderComponents/HeaderAuth';
import HeaderNoAuth from './HeaderComponents/HeaderNoAuth';
import CheckAuth from './scripts/CheckAuth';
import './style/Header.css'

function Header() {
    return (
      <div className="Header">
        <img src={logo} alt="logo" height={50} width={180} id="logo" />
        {CheckAuth() ? <HeaderAuth/> : <HeaderNoAuth/>}
      </div>
    );
  }
  
export default Header;