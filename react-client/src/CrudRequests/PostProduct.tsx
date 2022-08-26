import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const PostProduct = async (product: ProductModel): Promise<boolean> => {
    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Access-Control-Allow-Origin": "*",
        },
        body: JSON.stringify(product),
    };

    debugger;
    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${product.productId}`,
        requestOptions
    );
    const body = await result.json();
    return body as boolean;
};

export default PostProduct;
