import { useState } from "react";
import GetProduct from "../CrudRequests/GetProduct";
import ProductModel from "../Models/ProductModel";
import { Button, Form } from "react-bootstrap";
import { idInput } from "../Types/Types";

const GetProductComponent = (): JSX.Element => {
    const [product, setProduct] = useState<ProductModel | undefined>(undefined);

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & idInput;
                        async function init() {
                            let id: number = Number(target.productId.value);
                            const result = await GetProduct(id);
                            setProduct(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="productId">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                    </Form.Group>
                    <Button variant="btn btn-primary active" type="submit">
                        Get
                    </Button>
                </Form>
                <div>
                    Name: {product?.name || "product don't exist"}, Price:{" "}
                    {product?.price || ""}, About: {product?.shortDescription}
                </div>
            </div>
        </>
    );
};

export default GetProductComponent;
