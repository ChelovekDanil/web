import { Link, useNavigate } from "react-router-dom";

function HeaderAuth() {
    const navigate = useNavigate();

    return (
        <>
            <div className='NavigateBlock'>
                <Link to='/popularmovies' className='linkNav' id='popular'>Popular</Link>
                <Link to='/films' className='linkNav' id='film'>Films</Link>
                <Link to='/serials' className='linkNav' id='serial'>Serials</Link>
            </div>
            <div className="AuthBlock">
                <p className='linkAuth' id='logIn' onClick={ () => {
                    navigate("/profile")} }>Me</p>
            </div>
        </>
    )
}

export default HeaderAuth;