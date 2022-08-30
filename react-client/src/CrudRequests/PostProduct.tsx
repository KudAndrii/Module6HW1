import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const PostProduct = async (product: ProductModel): Promise<boolean> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(product),
    };

    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products`,
        requestOptions
    );
    const body = await result.json();
    return body as boolean;
};

export default PostProduct;
