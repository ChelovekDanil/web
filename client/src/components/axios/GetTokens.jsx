import axios from 'axios';  

function GetTokens(username) {
    axios.get(`https://localhost:7261/api/jwttoken/${username}`, {withCredentials: true})
            .then(response => {
                if (response.status === 200) {
                    localStorage.setItem("access_token", JSON.stringify(response.data));
                    return true;
                }
                else {
                    return false;
                }
            });
}

export default GetTokens;