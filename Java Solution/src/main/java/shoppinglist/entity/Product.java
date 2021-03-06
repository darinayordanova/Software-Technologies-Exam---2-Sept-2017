package shoppinglist.entity;

import javax.persistence.*;

@Entity
@Table(name = "products")
public class Product {
    private Integer id;

    private Integer priority;

    private String name;

    private Integer quantity;

    private String status;

    public  Product(){}

    public Product(Integer priority, String name, Integer quantity, String status) {
        this.priority = priority;
        this.name = name;
        this.quantity = quantity;
        this.status = status;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return this.id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public Integer getPriority() {
        return this.priority;
    }

    public void setPriority(Integer priority) {
        this.priority = priority;
    }

    @Column(nullable = false)
    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Column(nullable = false)
    public Integer getQuantity() {
        return this.quantity;
    }

    public void setQuantity(Integer quantity) {
        this.quantity = quantity;
    }

    @Column(nullable = false)
    public String getStatus() {
        return this.status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
