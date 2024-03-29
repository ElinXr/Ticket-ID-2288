<?php

namespace Models;

class Article
{
    private $id;
    private $title;
    private $content;
    private $created_at;
    private $updated_at;

    // Optional: Add properties for author, category, etc.

    public function __construct($id, $title, $content, $created_at = null, $updated_at = null)
    {
        $this->id = $id;
        $this->title = $title;
        $this->content = $content;
        $this->created_at = $created_at ?? new DateTime(); // Use current time if not provided
        $this->updated_at = $updated_at;
    }

    // Getters and Setters (optional)

    public function getId()
    {
        return $this->id;
    }

    public function setTitle($title)
    {
        $this->title = $title;
    }

    // ... other getters and setters

    public function toArray()
    {
        return [
            'id' => $this->id,
            'title' => $this->title,
            'content' => $this->content,
            'created_at' => $this->created_at->format('Y-m-d H:i:s'), // Format date for output
            'updated_at' => $this->updated_at ? $this->updated_at->format('Y-m-d H:i:s') : null, // Handle null value
        ];
    }
}



