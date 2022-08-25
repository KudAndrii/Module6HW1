import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const PutProduct = async (product: ProductModel): Promise<number> => {
    const requestOptions = {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(product),
    };

    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${product.id}`,
        requestOptions
    );
    const body = await result.json();
    return body as number;
};

export default PutProduct;
