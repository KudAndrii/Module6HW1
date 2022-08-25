import { useState } from "react";
import PostProduct from "../CrudRequests/PostProduct";
import { Button, Form } from "react-bootstrap";
import ProductModel from "../Models/ProductModel";

type Input = {
    product: {
        id: number;
        name: string;
        src: string;
        price: number;
        shortDescription: string;
        description: string;
    };
};

const DeleteProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<boolean>(false);

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & Input;
                        async function init() {
                            let product: ProductModel =
                                target.product as ProductModel;
                            const result = await PostProduct(product);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="product">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product name</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product src</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product price</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product shortDescription</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                        <Form.Label>
                            <i>Enter product description</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                    </Form.Group>
                    <Button variant="btn btn-primary active" type="submit">
                        Post
                    </Button>
                </Form>
                <div>Response: {responseStatus}</div>
            </div>
        </>
    );
};

export default DeleteProductComponent;
