<?php declare(strict_types=1);

namespace App\Enums;

use BenSampo\Enum\Attributes\Description;
use BenSampo\Enum\Enum;

final class OrderStatus extends Enum
{

    #[Description('Unprocessed')]
    public const UNPROCESSED = 0;

    #[Description('Delivering')]
    public const DELIVERING = 1;

    #[Description('Cancelled')]
    public const CANCELLED = 2;

    #[Description('Decline')]
    public const DECLINE = 3;

    #[Description('Successful')]
    public const SUCCESSFUL = 4;

    #[Description('Destroy')]
    public const DESTROY = 5;


}
