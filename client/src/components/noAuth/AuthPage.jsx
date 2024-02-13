import axios from 'axios';  
import './AuthPage.css'
import { useState } from 'react';

function AuthPage() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const ChangeUsername = (e) => {
        setUsername(e.target.value);
        console.log(e.target.value);
    }

    const ChangePassword = (e) => {
        setPassword(e.target.value);
    }

    const click = () => {
        axios.get(`https://localhost:7261/api/jwttoken/${username}`, {withCredentials: true})
            .then(response => {
                localStorage.setItem("access_token", JSON.stringify(response.data));
            });

        console.log(localStorage.getItem("accessToken"));
    }

    return (
        <div className="EnterWindow">
            <p id="login">Login</p>
            <p className="enterText">Enter your name</p>
            <input type="text" value={username} onChange={ChangeUsername}/>
            <p className="enterText">Enter your password</p>
            <input type="password" value={password} onChange={ChangePassword}/>
            <p id="enter" onClick={click}>Enter</p>
        </div>
    );
  }
  
export default AuthPage;