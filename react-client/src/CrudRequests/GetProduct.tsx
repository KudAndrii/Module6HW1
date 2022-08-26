import { appConfig } from "../apiConfig";
import ProductModel from "../Models/ProductModel";

const GetProduct = async (id: number): Promise<ProductModel> => {
    const result: Response = await fetch(
        `${appConfig.appUrl}/api/Products/${id}`,
        {
            headers: { "Access-Control-Allow-Origin": "*" },
        }
    );
    const body = await result.json();
    let product = new Object() as ProductModel;
    if (body) {
        product = body as ProductModel;
    }
    return product;
};

export default GetProduct;
