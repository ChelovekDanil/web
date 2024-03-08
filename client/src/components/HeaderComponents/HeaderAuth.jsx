import { Link } from "react-router-dom";

function HeaderAuth() {
    return (
        <>
            <div className='NavigateBlock'>
                <Link to='/popularmovies' className='linkNav' id='popular'>Popular</Link>
                <Link to='/films' className='linkNav' id='film'>Films</Link>
                <Link to='/serials' className='linkNav' id='serial'>Serials</Link>
            </div>
            <div></div>
        </>
    )
}

export default HeaderAuth;