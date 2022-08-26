import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const PutProduct = async (product: ProductModel): Promise<number> => {
    const requestOptions = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Access-Control-Allow-Origin": "*",
        },
        body: JSON.stringify(product),
    };

    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${product.productId}`,
        requestOptions
    );

    debugger;
    const body = await result.json();
    return body as number;
};

export default PutProduct;
