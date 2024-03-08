import { Link } from "react-router-dom";

function HeaderNoAuth() {
    return (
        <>
            <div className='NavigateBlock'>
                <Link to='/popularmovies' className='linkNav' id='popular'>Popular</Link>
                <Link to='/films' className='linkNav' id='film'>Films</Link>
                <Link to='/serials' className='linkNav' id='serial'>Serials</Link>
            </div>
            <div className='AuthBlock'>
                <Link to='/login' className='linkAuth' id='logIn'>Log in</Link>
                <Link to='/join' className='linkAuth' id='join'>Join</Link>
            </div>
        </>
    )
}

export default HeaderNoAuth;