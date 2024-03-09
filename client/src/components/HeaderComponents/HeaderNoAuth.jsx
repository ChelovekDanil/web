import { Link } from "react-router-dom";

function HeaderNoAuth() {
    return (
        <>
            <div className='NavigateBlock'>
                <Link to='/main' className='linkNav' id='popular'>Main</Link>
                <Link to='/about' className='linkNav' id='popular'>About</Link>
            </div>
            <div className='AuthBlock'>
                <Link to='/login' className='linkAuth' id='logIn'>Log in</Link>
                <Link to='/join' className='linkAuth' id='join'>Join</Link>
            </div>
        </>
    )
}

export default HeaderNoAuth;