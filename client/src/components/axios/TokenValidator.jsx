import axios from "axios";

const TokenValidator = () => {
    axios.get("https://localhost:7261/api/tokenvalidator")
        .then(response => {
            if (response === 200) return true;
            else if (response === 401) {
                
            };
        })
}

export default TokenValidator;