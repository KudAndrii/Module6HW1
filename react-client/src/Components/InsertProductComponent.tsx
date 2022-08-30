import { useState } from "react";
import PostProduct from "../CrudRequests/PostProduct";
import { Button, Form } from "react-bootstrap";
import ProductModel from "../Models/ProductModel";
import { productInput } from "../Types/Types";

const DeleteProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<boolean | undefined>(
        undefined
    );

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target &
                            productInput;
                        async function init() {
                            let product: ProductModel =
                                new Object() as ProductModel;

                            product.productId = Number(target.productId.value);
                            product.name = target.name.value;
                            product.url = target.url.value;
                            product.price = Number(target.price.value);
                            product.shortDescription =
                                target.shortDescription.value;
                            product.description = target.description.value;

                            const result = await PostProduct(product);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="productId">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control name="productId"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="name">
                        <Form.Label>
                            <i>Enter product name</i>
                        </Form.Label>
                        <Form.Control name="name"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="url">
                        <Form.Label>
                            <i>Enter product url</i>
                        </Form.Label>
                        <Form.Control name="url"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="price">
                        <Form.Label>
                            <i>Enter product price</i>
                        </Form.Label>
                        <Form.Control name="price"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="shortDescription">
                        <Form.Label>
                            <i>Enter product shortDescription</i>
                        </Form.Label>
                        <Form.Control name="shortDescription"></Form.Control>
                    </Form.Group>

                    <Form.Group controlId="description">
                        <Form.Label>
                            <i>Enter product description</i>
                        </Form.Label>
                        <Form.Control name="description"></Form.Control>
                    </Form.Group>

                    <Button variant="btn btn-primary active" type="submit">
                        Post
                    </Button>
                </Form>
                <div>
                    Response:{" "}
                    {responseStatus === undefined
                        ? ""
                        : responseStatus.toString()}
                </div>
            </div>
        </>
    );
};

export default DeleteProductComponent;
