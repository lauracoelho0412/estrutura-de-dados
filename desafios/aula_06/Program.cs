using System;
using System.Collections.Generic;

public class Node {
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    
    // Construtor
    public Node(int key) {
        this.Key = key;
    }
}

// BST é Binary Search Tree
public class BST {
    public Node Raiz { get; set; }
    
    private Node InsertB(int valor, Node raiz){
        Node no = new Node(valor);
        if(raiz == null){
            return new Node(valor); 
        }
        if(valor < raiz.Key){
           raiz.Left = InsertB(valor, raiz.Left);
        } else {
           raiz.Right = InsertB(valor, raiz.Right);
        }
        return raiz;
        
    }
    
    public void Insert(int valor){
       this.Raiz = InsertB(valor, this.Raiz); 
    }
    
    private Node SearchB(int valor, Node raiz){
        if(raiz == null || raiz.Key == valor) return raiz;
        if(valor < raiz.Key) {
            return SearchB(valor, raiz.Left);
        } else {
            return SearchB(valor, raiz.Right);
        }
    }
	
	public Node Search(int valor){
        return SearchB(valor, this.Raiz);
    }
	
	private Node MaximoN(Node raiz){
		if(raiz == null || raiz.Right == null) return raiz;
		return MaximoN(raiz.Right);
	}
	
	public Node Maximo(){
		return MaximoN(this.Raiz);
	}
	
	public Node MaxIterativo(){
		Node raiz = this.Raiz;
		Node maximo = this.Raiz;
		while(raiz != null){
			raiz = raiz.Right;
			if(maximo.Right != null)	maximo = maximo.Right;
		}
		return maximo;
	}
	
		private Node MinimoN(Node raiz){
		if(raiz == null || raiz.Left == null) return raiz;
		return MinimoN(raiz.Left);
	}
	
	public Node Minimo(){
		return MinimoN(this.Raiz);
	}
	
	public Node MinIterativo(){
		Node raiz = this.Raiz;
		Node minimo = this.Raiz;
		while(raiz != null){
			raiz = raiz.Right;
			if(minimo.Left != null)	minimo = minimo.Left;
		}
		return minimo;
	}

	private void InOrder(Node raiz) {
    if (raiz == null) return;
    
    InOrder(raiz.Left);       
    Console.Write(raiz.Key + " "); 
    InOrder(raiz.Right); 
	}

	public void PrintInOrder() {
    InOrder(this.Raiz);
    Console.WriteLine();
	}
	
	public void PrintInOrderIterativo() {
    Stack<Node> pilha = new Stack<Node>();
    Node atual = this.Raiz;

    while (atual != null || pilha.Count > 0) {
        while (atual != null) {
            pilha.Push(atual);
            atual = atual.Left;
        }

        atual = pilha.Pop();
        Console.Write(atual.Key + " ");

        atual = atual.Right;
    }

    Console.WriteLine();
	}
}


public class Program
{
	public static void Main()
	{
        BST bst = new BST();
        
        bst.Insert(15);
        bst.Insert(10);
        bst.Insert(8);
        bst.Insert(12);
        bst.Insert(20);
        bst.Insert(21);
        
        Console.WriteLine("In-order traversal (Sorted keys) (recursivo e iterativo):");
        bst.PrintInOrder();
		bst.PrintInOrderIterativo();
		
		Node maximo = bst.Maximo();
		Node maxIterativo = bst.MaxIterativo();
		Console.WriteLine("Max value (recursivo e iterativo):");
		Console.WriteLine($"{maximo.Key} {maxIterativo.Key}");
		
		Node minimo = bst.Minimo();
		Node minIterativo = bst.MinIterativo();
		Console.WriteLine("Min value (recursivo e iterativo):");
		Console.WriteLine($"{minimo.Key} {minIterativo.Key}");
	}
}