import axios from "axios";
import { getItemLocalStorage } from "../localStorege/localStorage";

const TokenValidator = async () => {
    try {
        const response = await axios.get("https://localhost:7261/api/tokenvalidator", {
            withCredentials: true, 
            headers: {
                Authorization: `Bearer ${JSON.parse(localStorage.getItem("access_token"))}`
            }
        });
        if (response.status === 200) {
            return true;
        } else if (response.status === 401) {
            const refreshResponse = await axios.get(`https://localhost:7261/api/RefreshToken?username=${getItemLocalStorage("user_name")}`);
            console.log(refreshResponse.data);
            return true;
        }
    } catch (error) {
        console.log("error", error);
    }
}

export default TokenValidator;
