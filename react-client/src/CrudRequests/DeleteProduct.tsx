import { appConfig } from "../apiConfig";

const DeleteProduct = async (id: number): Promise<boolean> => {
    const requestOptions = {
        method: "DELETE",
    };
    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${id}`,
        requestOptions
    );
    const body = await result.json();
    return body as boolean;
};

export default DeleteProduct;
