import { appConfig } from "../apiConfig";

const DeleteProduct = async (id: number): Promise<boolean> => {
    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${id}`,
        { method: "DELETE" }
    );
    const body = await result.json();
    return body as boolean;
};

export default DeleteProduct;
