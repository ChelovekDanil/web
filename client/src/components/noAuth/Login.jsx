import './Login.css'
import { useState } from 'react';
import { Link, useNavigate     } from 'react-router-dom';
import LoginAxios from '../axios/LoginAxios';

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const ChangeUsername = (e) => {
        setUsername(e.target.value);
    }

    const ChangePassword = (e) => {
        setPassword(e.target.value);
    }

    // get access and refresh token
    function click () {
        if (username != "" && password != "") {
            LoginAxios(username, password);
            navigate("/popularmovies");
        }
        else {
            alert("Enter all fields!")
        }
    }

    return (
        <div className="EnterWindow">
            <p className="login">Login</p>
            <input type="text" className="input" value={username} onChange={ChangeUsername} placeholder='Username'/>
            <input type="password" className="input" value={password} onChange={ChangePassword} placeholder='Password'/>
            <Link to="/join" className="GoToJoin">Join</Link>
            <p className="enter" onClick={click}>Enter</p>
        </div>
    );
  }
  
export default Login;