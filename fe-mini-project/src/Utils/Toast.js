import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

export const ShowSuccessAlert = (message) => {
    toast.success(message, {
        position:"bottom-right",
        autoClose: 5000,
        closeOnClick:true
    });
};

export const ShowErrorAlert = (message) => {
    toast.error(message, {
        position:"bottom-right",
        autoClose: 5000,
        closeOnClick:true
    })
}
